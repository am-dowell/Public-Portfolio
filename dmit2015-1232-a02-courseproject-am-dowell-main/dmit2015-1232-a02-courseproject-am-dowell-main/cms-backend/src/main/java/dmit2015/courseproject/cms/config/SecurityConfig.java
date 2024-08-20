package dmit2015.courseproject.cms.config;

import dmit2015.courseproject.cms.service.UserService;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.HttpMethod;
import org.springframework.security.config.Customizer;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.http.SessionCreationPolicy;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.web.SecurityFilterChain;
import org.springframework.security.web.authentication.www.BasicAuthenticationFilter;
@RequiredArgsConstructor
@Configuration
@EnableWebSecurity
public class SecurityConfig {

    private final UserAuthenticationEntryPoint userAuthenticationEntryPoint;
    private final UserAuthenticationProvider userAuthenticationProvider;

    @Configuration
    @EnableWebSecurity
    public class CustomSecurityConfig {

        @Autowired
        @Qualifier("userAuthenticationEntryPoint")
        UserAuthenticationEntryPoint authEntryPoint;

        @Bean
        public UserService userDetailsService() {
            UserDetails admin = User.withUsername("admin")
                    .password("password")
                    .roles("ADMIN")
                    .build();
            InMemoryUserDetailsManager userDetailsManager = new InMemoryUserDetailsManager();
            userDetailsManager.createUser(admin);
            return userDetailsManager;
        }

        @Bean
        public SecurityFilterChain filterChain(HttpSecurity http) throws Exception {
            http.authorizeHttpRequests(auth -> auth
                            .requestMatchers("/login")
                            .authenticated()
                            .anyRequest()
                            .hasRole("ADMIN"))
                    .httpBasic(basic -> basic.authenticationEntryPoint(authEntryPoint))
                    .exceptionHandling(Customizer.withDefaults());
            return http.build();
        }
    }